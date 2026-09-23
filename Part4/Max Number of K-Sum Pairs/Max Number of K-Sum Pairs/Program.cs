namespace Max_Number_of_K_Sum_Pairs
{
    internal class Program
    {

      static  public int MaxOperations(int[] nums, int k)
        {
            int left = 0;
            int right = nums.Length - 1;
            int operation = 0;
            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == k)
                {
                    left++;
                    right--;
                    operation++;
                }
                else if (sum < k)
                {
                    left++;
                }
                else
                    right --;
            }
            return operation;
        }
        static void Main(string[] args)
        {
            int[] nums = [1, 2, 3, 4];
            int k = 5;
            Console.WriteLine(MaxOperations(nums,k));
        }
    }
}
