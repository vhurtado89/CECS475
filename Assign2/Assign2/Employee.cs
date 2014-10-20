﻿// Fig. 12.13: Employee.cs
// Employee abstract base class.
using System;
using System.Collections;

public abstract class Employee : IPayable, IComparable
{
    // read-only property that gets employee's first name
    public string FirstName { get; private set; }

    // read-only property that gets employee's last name
    public string LastName { get; private set; }

    // read-only property that gets employee's social security number
    public string SocialSecurityNumber { get; private set; }

    // three-parameter constructor
    public Employee(string first, string last, string ssn)
    {
        FirstName = first;
        LastName = last;
        SocialSecurityNumber = ssn;
    } // end three-parameter Employee constructor

    // return string representation of Employee object
    public override string ToString()
    {
        return string.Format("{0} {1}\nsocial security number: {2}",
           FirstName, LastName, SocialSecurityNumber);
    } // end method ToString

    int IComparable.CompareTo(object obj)
    {
       Employee tmp = (Employee)obj;
       if(this.LastName.Equals(tmp.LastName)){ //if last names are the same 
           if(this.FirstName.Equals(tmp.FirstName)){//if first names are the same
               return this.SocialSecurityNumber.CompareTo(tmp.SocialSecurityNumber);
           }
           else
               return this.FirstName.CompareTo(tmp.FirstName);
       } 
        else
           return tmp.LastName.CompareTo(this.LastName);
    }
    private class sortAscendingHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee tmp1 = (Employee)a;
            Employee tmp2 = (Employee)b;

            if (tmp1.GetPaymentAmount() > tmp2.GetPaymentAmount())
            {
                return 1;
            }
            else if (tmp1.GetPaymentAmount() < tmp2.GetPaymentAmount())
            {
                return -1;
            }
            else
                return 0;

        }
    }
    public static IComparer sortPayAmountAscending()
    {
        return(IComparer) new sortAscendingHelper();
    }
    private class sortDescendingHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Employee tmp1 = (Employee)a;
            Employee tmp2 = (Employee)b;

            if (tmp1.GetPaymentAmount() < tmp2.GetPaymentAmount())
            {
                return 1;
            }
            else if (tmp1.GetPaymentAmount() > tmp2.GetPaymentAmount())
            {
                return -1;
            }
            else
                return 0;

        }
    }
    public static IComparer sortPayAmountDescending()
    {
        return (IComparer)new sortDescendingHelper();
    }


    // Note: We do not implement IPayable method GetPaymentAmount here so
    // this class must be declared abstract to avoid a compilation error.
    public abstract decimal GetPaymentAmount();
    public abstract int getSSN();
} // end abstract class Employee

/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************/