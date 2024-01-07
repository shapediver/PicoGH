
using System;

class PicoGKExample
{
    static void Main(string[] args)
    {
        try
        {
            PicoGK.Library.Go(0.5f, PicoGKExamples.BooleanShowCase.Task);
        }

        catch (Exception e)
        {
            // Apparently something went wrong, output here
            Console.WriteLine(e);
        }
    }
}

