using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


    public class Hash_program
{
		public static String reversehashfunction(long hashval) {
		StringBuilder code = new StringBuilder();
		String letters = "acdegilmnoprstuw";
 
		int index = 0;
 		while (hashval > 7) {
 
 
			if (hashval % 37 == 0) {
 
				code.Append(letters[index]);
				index = 0;
				hashval /= 37;
 
			}
			else {
 
				hashval -= 1;
				index += 1;
 
			}
 
 
		}

 	StringBuilder revStr = new StringBuilder();
	 for (int count = code.Length - 1; count > -1; count--)
        {
            revStr.Append(code[count]);
        }
        
         return revStr.ToString();

	}
 
 
	public static void Main()
	{
		
		long hashval = 680131659347L;
		
		Console.WriteLine(reversehashfunction(hashval));
 
		
	}
}
