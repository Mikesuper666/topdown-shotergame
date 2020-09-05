using System.Collections;

public static class Utility
{
    public static T[] ShuffleArray<T>(T[] array, int seed)
    {
        System.Random prng = new System.Random(seed);

        for (int i = 0; i < array.Length - 1; i++)
        {
            int ramdomIndex = prng.Next(i, array.Length);
            T tempItem = array[ramdomIndex];
            array[ramdomIndex] = array[i];
            array[i] = tempItem;
        }

        return array;
    }
}
