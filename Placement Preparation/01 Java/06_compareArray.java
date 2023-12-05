//Given	two	arrays,	1,	2,3,4,5	and	2,	3,1,0,5	find	which	number	is	not	present	in	the	second	array.
public class compareArray {
    public static void main(String[] args) {
        int[] arr1 = {1,2,3,4,5};
        int[] arr2 = {2,6,1,0,5};
    
        for(int i=0; i<arr1.length; i++){
           int count = 0;
          for(int j=0; j<arr2.length; j++){
            if(arr1[i] == arr2[j]){
                count = 1;
            }
          }
          if(count == 0){
            System.out.println(arr1[i]);
          }
        }
    } 
}