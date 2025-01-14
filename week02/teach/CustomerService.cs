using System.Diagnostics;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: The user will specify an invalid size.
        // Expected Result: The software will use the default size of 10.
        Console.WriteLine("Test 1");

        // Defect(s) Found: 
        var customerService = new CustomerService(-1); //Inputing an invalid size.
        if (customerService._maxSize == 10)
        {
            Console.WriteLine("Pass test 1");
        }
        else
        {
            Console.WriteLine("Test 1 fail");
            Trace.Assert(customerService._maxSize == 10, "Default size must be 10.");
        }
        

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Enqueuing a new customer into the queue.
        // Expected Result:  The customer will be correctly put in thE queue
        Console.WriteLine("Test 2");
        
        customerService = new CustomerService(3);

        var input = "Robson Paulo da Silva\nId001\nNotebook batery problem\n";
        var stringReader = new StringReader(input);
        Console.SetIn(stringReader);
        customerService.AddNewCustomer();
        // Defect(s) Found: Let's include a single client, 
        //if we don't find this same client at the beginning 
        //of the queue when executing dequeuing this will be an error.
        if (customerService.ToString() == "[size=1 max_size=3 => Robson Paulo da Silva (Id001)  : Notebook batery problem]")
        {
            Console.WriteLine("Pass test 2");
        }
        else
        {
            Console.WriteLine("Test 2 fail");
            Trace.Assert(customerService.ToString() == "[size=1 max_size=10 => Robson Paulo da Silva (Id001)  : Notebook batery problem]");
        }
        
        Console.WriteLine("=================");
        Console.WriteLine("Test 3");
        // Add more Test Cases As Needed Below
        //I put a client in these tests before
        //Test 3
        //Scenario: Queue full
        // Expected Result: If the queue is full when trying to add a customer, then an error message will be displayed.
        //Defect:If the queue is full but no error message is found.
        
        customerService = new CustomerService(3);
        for (int i = 0; i<4; i++) //Try to put 4 customers in a queue with size 3
        {
            var inp = $"Name {i}\nIdt00{i}\nProblem{i}\n";
            var strReader = new StringReader(inp);
            Console.SetIn(strReader);

            if (i == 3)
            {
                Console.SetIn(Console.In);   
            }
            customerService.AddNewCustomer();
        }
        if (customerService._queue.Count() == 3)
        {
            Console.WriteLine("Pass test 3");
        }
        else
        {
            Console.WriteLine("Test 3 fail");
            Trace.Assert(customerService._queue.Count() > 3, "Error, the application accepted to include more clients than the amount supported by the service.");
        }

        Console.WriteLine("=================");
        Console.WriteLine("Test 4");
        //Test 4
        //Scenario: Dequeuing a item correctly
        // Expected Result: If I queue two itens I must dequeue in the correct order.
        //Defect:If the dequeue fail it is a error.

        customerService = new CustomerService(2);

        input = "Robson\nId001\nNotebook batery problem\n";
        stringReader = new StringReader(input);
        Console.SetIn(stringReader);
        
        customerService.AddNewCustomer();

        input = "Paulo\nId002\nMobile problem\n";
        stringReader = new StringReader(input);
        Console.SetIn(stringReader);

        customerService.AddNewCustomer();
        customerService.ServeCustomer();


        Console.WriteLine(customerService.ToString().Trim());
        if (customerService.ToString().Trim() == 
            "[size=1 max_size=2 => Paulo (Id002)  : Mobile problem]")
        {
            Console.WriteLine("Pass test 4");
        }
        else
        {
            Console.WriteLine("Test 4 fail");
            Trace.Assert(false, "Error dequeuing clients.");
        }

        Console.WriteLine("=================");
        Console.WriteLine("Test 5");
        //Test 5
        //Scenario: Dequeuing a item with queue empty
        // Expected Result: An error message will be displayed
        //Defect:No message if queue is empty.
        customerService = new CustomerService(2);
        customerService.ServeCustomer();

    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count + 1 > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count()>=1)
        {
            _queue.RemoveAt(0);
            var customer = _queue[0];
            Console.WriteLine(customer);
        }
        else
        {
            Console.WriteLine("Queue empty");
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}