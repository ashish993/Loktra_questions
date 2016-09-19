using System;
using System.Text.RegularExpressions;

public class Uriprogram
{
	public static void Main()
	{
Console.WriteLine("Enter Url\n");
   string url = Console.ReadLine();

//"http://www.cambiaresearch.com/Cambia3/snippets/csharp/regex/uri_regex.aspx?id=17#authority"
   string patternregex = @"^(?<s1>(?<s0>[^:/\?#]+):)?(?<a1>" 
      + @"//(?<a0>[^/\?#]*))?(?<p0>[^\?#]*)" 
      + @"(?<q1>\?(?<q0>[^#]*))?" 
      + @"(?<f1>#(?<f0>.*))?";

   Regex re = new Regex(patternregex, RegexOptions.ExplicitCapture); 
   Match m = re.Match(url);
	string finalOutput;
   finalOutput= "URL: " + url + "\n";

   finalOutput+=
      m.Groups["s0"].Value + "  Scheme without colon\n"; 
   finalOutput+=
      m.Groups["s1"].Value + "  Colon Scheme\n"; 
   finalOutput+=  
      m.Groups["a0"].Value + "  Without //Authority\n"; 
   finalOutput+=  
      m.Groups["a1"].Value + "  Authority with //\n"; 
   finalOutput+=  
      m.Groups["p0"].Value + "  Dir Path\n"; 
   finalOutput+=  
      m.Groups["q0"].Value + "  Query without ?\n"; 
   finalOutput+=  
      m.Groups["q1"].Value + "  (Query with ?)\n"; 
   finalOutput+=  
      m.Groups["f0"].Value + "  Fragment without #\n"; 
   finalOutput+= 
      m.Groups["f1"].Value + "  Fragment with #\n"; 

Console.WriteLine(finalOutput);
	}
}