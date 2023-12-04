public class swapArray {
    public static void main(String[] args) {
        int[] arr = {1,2,3,4,5,6,7};

        for(int i=1; i<arr.length; i++){
            int temp = arr[i-1];
            arr[i-1] = arr[i];
            arr[i] = temp;
        }

        for(int i=0; i<arr.length; i++){
            System.out.print(arr[i] + " ");
        }
    }    
}