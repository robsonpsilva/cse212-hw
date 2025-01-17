/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        else
        {
            Person person = _people.Dequeue();
            if (person.Turns > 1)
            {
                person.Turns -= 1;
                _people.Enqueue(person);
            }
            else //Fixed code, the scenario where a person will be enqueue forever was not coded.
            {
                /*
                    The requirement has a somewhat ambiguous definition regarding the criteria for
                    a person to be placed in the queue forever, that is, the value of the Turns attribute 
                    must be zero. However, for those with Turns greater than zero, the code needs to decrement 
                    its value each round to stop placing the person back in the queue. This action, performed directly on the Turns variable, 
                    will eventually result in it assuming the value zero. 
                    Which, according to the requirement, makes it eternal and the person will be placed in the queue indefinitely.

                    In order not to change the requirements, I created an additional attribute that stores the original number of Turns 
                    and never decrements, so we can validate whether it was zero at the beginning, and if so, correctly keep that person 
                    in the queue forever.
                */
                if (person.ForeverTurns <= 0)
                {
                    _people.Enqueue(person);
                }                
                 
            }

            return person;
        }
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}