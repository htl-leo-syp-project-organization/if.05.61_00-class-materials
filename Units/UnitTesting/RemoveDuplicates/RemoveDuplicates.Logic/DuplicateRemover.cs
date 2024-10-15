namespace RemoveDuplicates.Logic
{
    public class DuplicateRemover
    {
        public static int[] RemoveFrom(int[] input)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (result.Contains(input[i]) == false)
                {
                    result.Add(input[i]);
                }
            }
            return result.ToArray();
        }
    }
}
