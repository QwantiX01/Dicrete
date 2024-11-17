namespace Combinatorics.Comb;

public static class Sorting
{
    public static void SortInsertion(int[] array, int startIndex, int endIndex)
    {
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            int key = array[i];
            int j = i - 1;

            // Переміщуємо елементи, які більші за ключ, на одну позицію вправо
            while (j >= startIndex && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }

}