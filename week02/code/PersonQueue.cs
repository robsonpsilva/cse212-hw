/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        //_queue.Insert(0, person);
        /*
            I found the error here, it should be a queue, 
            but the code is placing the elements as if it were a stack, 
            because it was placed at the front of the list, and the standard 
            behavior of a list is to move the other elements one position 
            forward, so the first one to enter will always be taken to the 
            end of the queue.
        */
        _queue.Add(person); //Correcting the code, puting every element in the  end of the list.
        
    }

    public Person Dequeue()
    {
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}