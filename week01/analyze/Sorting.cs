public static class Sorting {
    public static void Run() {
        var numbers = new[] { 9, 8, 6, 4, 3, 2, 1};
        SortArray(numbers);
        Console.Out.WriteLine("int[]{{{0}}}", string.Join(", ", numbers)); //int[]{1, 2, 3, 4, 6, 8, 9}
    }

    private static void SortArray(int[] data) { //O(n^2) - It adds up the numbers between 1 and n, the total of which is calculated by the formula t = n * (n-1)/2 which is O(n^2).
        int count = 0;
        for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--) {
            for (var swapPos = 0; swapPos < sortPos; ++swapPos) {
                if (data[swapPos] > data[swapPos + 1]) {
                    (data[swapPos + 1], data[swapPos]) = (data[swapPos], data[swapPos + 1]);
                    count++;
                }
            }
        }
        Console.WriteLine(count);
    }
}