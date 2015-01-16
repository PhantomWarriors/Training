using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.IO;

namespace SimpleHTTPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = null; // прослушиватель http протокола

            try
            {
                listener = new HttpListener(); // обявляем listener
                listener.Prefixes.Add("http://localhost:5000/index/"); // указываем префикс URL который будем слушать
                listener.Start(); // запуск прослушивателя, позволят получать входящие запросы
                while (true) // запускаем бесконечный цикл
                {
                    Console.WriteLine("Start");
                    HttpListenerContext context = listener.GetContext(); // предоставляет доступ к объектам запросов и ответов. GetContext - Ожидает входящий запрос и выполняет возврат при получении такого запроса.
                    string msg = 
 "<html>" + "\n"+
"<head>" + "\n" +
" <script type=\"text/javascript\"> " + "\n"+
"var but = [[7,8,9,'/'], [4,5,6,'*'], [1,2,3,'-'],[0,'C','=','+']]; " + "\n"+
"</script>" + "\n"+ 

"<body>" + "\n"+
"<script type=\"text/javascript\">" + "\n"+
"var status = 1" + "\n" +
	"var x = 0" + "\n"+
	"var y = 0" + "\n"+
	"var opp = '='" + "\n"+

"document.write (\"<form name='calculator'>\")" + "\n"+
"document.write(\"<input type='text' value='0' name='display' style='width:100; height:25;'/>\");" + "\n"+

"for(var i = 0; i < but.length; i++)" + "\n"+
"{" + "\n"+
    "document.write(\"<div>\");" + "\n"+
    "for(var j = 0; j < but[i].length; j++)" + "\n"+
    "{" + "\n"+
	"if (typeof but[i][j]==\"number\")" + "\n"+
		"{" + "\n"+
       "document.write(\"<input type='button' value='\" + but[i][j] + \"' style='width:25; height:25;' onclick='Numbers(\" + but[i][j] + \")'/>\");" + "\n"+
	   "}" + "\n"+
	   "else if  (but[i][j]==\"C\")" + "\n"+
	   "{" + "\n"+
	  " document.write(\"<input type='button' value='\" + but[i][j] + \"' style='width:25; height:25;' onclick='clearDisplay()'/>\");" + "\n"+
	   "}" + "\n"+
	   "else" + "\n"+
	   "{" + "\n"+
	   "document.write(\"<input type='button' value='\" + but[i][j] + \"' style='width:25; height:25;' onclick='Operations(this)'/>\");" + "\n"+
	   "}" + "\n"+
    "}" + "\n"+
    "document.write(\"</div>\");" + "\n"+
"}" + "\n"+
"document.write (\"</form>\")" + "\n"+

	"function Operations(op)" + "\n"+
	"{" + "\n"+
		"y = parseFloat(document.calculator.display.value)" + "\n"+
		
		"switch(opp)" + "\n"+
		"{" + "\n"+
			"case '+':" + "\n"+
			"x = x + y" + "\n"+
			"break;" + "\n"+
			"case '-':"+ "\n"+
			"x = x - y" + "\n"+
			"break;" + "\n"+
			"case '/':" + "\n"+
			"x = x / y" + "\n"+
			"break;" + "\n"+
			"case '*':" + "\n"+
			"x = x * y" + "\n"+
			"break;" + "\n"+
			"case '=':" + "\n"+
			"x = y" + "\n"+
		"}" + "\n"+
		"if (y==0 && opp=='/')" + "\n"+
			"{" + "\n"+
				"document.calculator.display.value='јт-та-та!!!'" + "\n"+
				"opp='='" + "\n"+
				"x=0;" + "\n"+
				"y=0;" + "\n"+
			"}" + "\n"+
		"else " + "\n"+
		"{" + "\n"+
				"document.calculator.display.value = x" + "\n"+
		"}" + "\n"+
		"status = 1" + "\n"+
		"opp = op.value" + "\n"+
	"}" + "\n"+
		
	"function clearDisplay()" + "\n"+
	"{" + "\n"+
		"document.calculator.display.value = 0" + "\n"+
		"status = 1" + "\n"+
		"x = 0" + "\n"+
		"y = 0" + "\n"+
		"opp = '='" + "\n"+
	"}" + "\n"+
	
	"function Numbers(num)" + "\n"+
	"{" + "\n"+
		"if (status == 1)" + "\n"+
		"{" + "\n"+
			"document.calculator.display.value = num" + "\n"+
			"if(document.calculator.display.value != 0)" + "\n"+
			"{" + "\n"+
				"status = 0"+ "\n"+
			"}" + "\n"+
		"}" + "\n"+
		"else" + "\n"+
		"{" + "\n"+
			"document.calculator.display.value = document.calculator.display.value + num" + "\n"+
		"}" + "\n"+
	"}" + "\n"+

"</script>" + "\n"+
"</body>" + "\n"+
"</html>" + "\n";

                  //  context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg); // Возвращает количество байтов в данных основного текста, включенных в ответ. Считает количество байтов в заданной строке
                   // context.Response.StatusCode = (int)HttpStatusCode.OK; // возвращает код состояния http

                    using (Stream str = context.Response.OutputStream) // Возвращает объект Stream, в который можно записать ответ.
                    {
                        using (StreamWriter writer = new StreamWriter(str)) // записываем ответ
                        {
                            writer.Write(msg);
                        }
                    }
                    Console.WriteLine("msg send....");
                }

            }
            catch (WebException e)
            {
                Console.WriteLine(e.Status);
            }
            
        }
    }
}
