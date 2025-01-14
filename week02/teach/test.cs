 /*
 var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            customerService.AddNewCustomer();
            Console.SetOut(Console.Out);

            var output = stringWriter.ToString().Trim();
            var lines = output.Split(":");
            var tLine = lines[lines.Length - 1].Trim();
            if (tLine == "Maximum Number of Customers in Queue." && i == 10)
            {

                Console.WriteLine("Pass test 3");
            }
            if (tLine == "Maximum Number of Customers in Queue." && i < 10
            || !(tLine == "Maximum Number of Customers in Queue.") && i == 10)
            {
                Trace.Assert(false);
            } 

*/