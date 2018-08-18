using System;

public class Enemy
{
    private int x = 0, y = 0;
	public Enemy()
    {
        
        Random rnd = new Random();
        
        rnd.Next(0, 101);
        rnd.Next(0, 101);
    }
}
