namespace Generics;

public class Person
{
    public string PersonalNumber { get; set; }
}

public class Employee : Person
{
    public decimal Salary { get; set; }
}

public class Customer : Person
{
    public string PhoneNumber { get; set; }
    public decimal TotalPurchase { get; set; }
}

public interface IObject
{
    public int Id { get; set; }
}

public struct SimpleObject : IObject
{
    public int Id { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // TryCatchExample.Run();
        // TypeCastingExample.Run();

        var collection = new Account[] { new Account(1) { Balance = 1000 }, new Account(2) { Balance = 20 } };

        var index = IndexOf(collection, new Account(2) { Balance = 1000 }, new AccountBalanceComparer());
        index = IndexOf(collection, new Account(2), new AccountIdComparer());
    }

    public static int IndexOf<T>(IList<T> collection, T value) where T : IEquatable<T>
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].Equals(value))
            {
                return i;
            }
        }

        return -1;
    }

    public static int IndexOf<T>(IList<T> collection, T value, IEqualityComparer<T> comparer) where T : IEquatable<T>
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (comparer.Equals(collection[i], value))
            {
                return i;
            }
        }

        return -1;
    }
}

public interface IDatabaseWritable<TId> where TId : IComparable<TId>
{
    void WriteInDb(TId id);
}

public abstract class DomainObject<TId> : IDatabaseWritable<TId>
    where TId : IComparable<TId>
{
    public TId Id { get; set; }

    public abstract void WriteInDb(TId id);
}

public class Account : DomainObject<int>, IEquatable<Account>
{
    public Account(int id)
    {
        Id = id;
    }

    public decimal Balance { get; set; }

    public override void WriteInDb(int id)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Account? other)
    {
        if (other == null)
            return false;

        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Account)obj);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}

public class Transaction : DomainObject<long>
{
    public Transaction(long id)
    {
        Id = id;
    }

    public override void WriteInDb(long id)
    {
        throw new NotImplementedException();
    }
}

public class AccountIdComparer : IComparer<Account>, IEqualityComparer<Account>
{
    public int Compare(Account? x, Account? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (y is null) return 1;
        if (x is null) return -1;

        return x.Id.CompareTo(y.Id);
    }

    public bool Equals(Account? x, Account? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Id == y.Id;
    }

    public int GetHashCode(Account obj)
    {
        return HashCode.Combine(obj.Id, obj.Balance);
    }
}

public class AccountBalanceComparer : IComparer<Account>, IEqualityComparer<Account>
{
    public int Compare(Account? x, Account? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (y is null) return 1;
        if (x is null) return -1;

        return x.Balance.CompareTo(y.Balance);
    }

    public bool Equals(Account? x, Account? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;

        return x.Balance == y.Balance;
    }

    public int GetHashCode(Account obj)
    {
        return HashCode.Combine(obj.Id, obj.Balance);
    }
}