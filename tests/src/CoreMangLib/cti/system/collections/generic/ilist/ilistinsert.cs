using System;
using System.Collections.Generic;
/// <summary>
///Insert(System.Int32,T)
/// </summary>
public class IListInsert
{
    public static int Main()
    {
        IListInsert IListInsert = new IListInsert();
        TestLibrary.TestFramework.BeginTestCase("IListInsert");
        if (IListInsert.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negitive]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Calling Insert method ,T is value type. ");
        try
        {
            IList<int> myList=new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                myList.Add(i*100);
            }
            int index=1;
            int expectValue = 999;
            myList.Insert(index, expectValue);
            int actualValue = myList[index];
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.1", "Calling IndexOf method return a value incorrectly,should return " + expectValue);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest2: Calling Insert method ,T is reference type. ");
        try
        {
            IList<string> myList = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                myList.Add(i.ToString());
            }
            int index = 1;
            string expectValue = "HELLO";
            myList.Insert(index, expectValue);
            string actualValue = myList[index];
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("002.1", "Calling IndexOf method return a value incorrectly,should return " + expectValue);
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }

    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest3()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest3: Calling indexof method ,T is user define type. ");
        try
        {
            IList<MyTestClass> myList = new List<MyTestClass>();
            MyTestClass myTest=null;
            for (int i = 1; i <= 10; i++)
            {
                myTest = new MyTestClass();
                myTest.ID = i;
                myList.Add(myTest);
            }
            int index = 1;
            MyTestClass expectValue = new MyTestClass();
            expectValue.ID = 999;
            myList.Insert(index, expectValue);
            MyTestClass actualValue = myList[index];
            if (actualValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("003.1", "Calling IndexOf method return a value incorrectly,should return " + expectValue);
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("003.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }

    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("NegTest1: index is not a valid index in the IList.");
        try
        {
            IList<string> myList = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                myList.Add(i.ToString());
                
            }
            int index = 100;
            string expectValue = "HELLO";
            myList.Insert(index, expectValue);
            TestLibrary.TestFramework.LogError("101.1", "ArgumentOutOfRangeException should be caught.");
            retVal = false;
        }
        catch (ArgumentOutOfRangeException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("NegTest2: The IList is read-only.");
        try
        {
            IList<string> myList = new MyList<string>();
            int index = 1;
            string expectValue = "HELLO";
            myList.Insert(index, expectValue);
            TestLibrary.TestFramework.LogError("101.1", "NotSupportedException should be caught.");
            retVal = false;
        }
        catch (NotSupportedException)
        {

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("101.0", "Unexpected exception: " + e);
            retVal = false;
        }
        return retVal;
    }

}
public class MyTestClass
{
    private int id=0;
    public MyTestClass()
    {

    }
    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }

}
public class MyList<T> : IList<T>
{

    #region IList<T> Members

    public int IndexOf(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException();
    }

    public void RemoveAt(int index)
    {
        throw new Exception("The method or operation is not implemented.");
    }
   
    public T this[int index]
    {
        get
        {
            throw new Exception("The method or operation is not implemented.");
        }
        set
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    #endregion

    #region ICollection<T> Members
    public void Clear()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public bool Contains(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    public int Count
    {
        get { throw new Exception("The method or operation is not implemented."); }
    }

    public bool IsReadOnly
    {
        get { return true; }
    }

    public bool Remove(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IEnumerable<T> Members

    public IEnumerator<T> GetEnumerator()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region ICollection<T> Members

    public void Add(T item)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    #endregion
}