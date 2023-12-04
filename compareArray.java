import java.util.ArrayList;

public class compareArray {
    public static void main(String[] args) {
        int[] arr1 = {1,2,3,4,5};
        int[] arr2 = {2,6,1,0,5};
        ArrayList arr = new ArrayList<>();
        int[] arr3 = new int[5];

        for(int i=0; i<arr1.length; i++){
           int count = 0;
          for(int j=0; j<arr2.length; j++){
            if(arr1[i] == arr2[j]){
                count = 1;
            }
          }
          if(count == 0){
            arr.add(arr1[i]);
          }
        }
        
        System.out.println(arr);
    } 
}