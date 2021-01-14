using Xunit;

namespace LeetCode._81._90
{
    public class Task88
    {
        [Theory]
        [InlineData(new[] {1,2,3,0,0,0}, 3, new[] {2,5,6}, 3,new[] {1,2,2,3,5,6})] 
        [InlineData(new[] {5,6,0,0}, 2, new[] {2,3}, 2, new[] {2,3,5,6})]
        [InlineData(new[] {1,2,0,0}, 2, new[] {3,4}, 2, new[] {1,2,3,4})]
        public void Run(int[] nums1, int m, int[] nums2, int n, int[] expected)
        {
            Merge(nums1, m, nums2, n);
            Assert.Equal(nums1, expected);
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n) {
        
            int t = nums1.Length - 1;
            m--;
            n--;
            while (t>= 0 && (m >= 0 || n >= 0))
            {
                if (m < 0)
                {
                    for (int i = 0; i <= n; i++)
                    {
                        nums1[i] = nums2[i];
                    }
                    break;
                }
            
                if (n < 0)
                {
                    break;
                }
            
                if (nums1[m] <= nums2[n])
                {
                    nums1[t] = nums2[n];
                    n--;
                    t--;
                    continue;
                }
            
                if (nums1[m] > nums2[n])
                {
                    nums1[t] = nums1[m];
                    m--;
                    t--;
                }
            }
        }        
    }
}