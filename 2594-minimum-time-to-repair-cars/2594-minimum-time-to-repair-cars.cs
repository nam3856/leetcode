public class Solution
{
    public long RepairCars(int[] ranks, int cars)
    {
        // 최소 시간은 1이며,
        // 최대 시간은 가장 느린 정비공(최고의 rank)이 모든 차를 수리할 때 걸리는 시간
        long low = 1;
        long high = (long)ranks[0] * cars * cars;

        // 최소 시간을 찾기 위해 이분 탐색을 수행
        while (low < high)
        {
            long mid = (low + high) / 2;
            long carsRepaired = 0;

            // 모든 정비공이 'mid' 시간 동안 수리할 수 있는 차의 개수를 계산
            foreach (int rank in ranks)
            {
                carsRepaired += (long)Math.Sqrt((1.0 * mid) / rank);
            }

            // 총 수리된 차의 개수가 필요한 차의 개수보다 작으면, 시간을 늘린다
            if (carsRepaired < cars)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }
}
