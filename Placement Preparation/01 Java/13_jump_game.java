// You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array
// represents your maximum jump length at that position. Return true if you can reach the last index, or false otherwise.

// Example 1:
// Input: nums = [2,3,1,1,4]
// Output: true
// Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

// Example 2:
// Input: nums = [3,2,1,0,4]
// Output: false
// Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.
// 1,1,2,2,0,1,1
// 1,3,1,0,1,3,1,0,1
// 5,9,3,2,1,0,2,3,3,1,0,0
class gump_game {
    public static void main(String[] args) {
        int[] nums = { 8,2,4,4,4,9,5,2,5,8,8,0,8,6,9,1,1,6,3,5,1,2,6,6,
            0,4,8,6,0,3,2,8,7,6,5,1,7,0,3,4,8,3,5,9,0,4,0,1,0,5,9
            ,2,0,7,0,2,1,0,8,2,5,1,2,3,9,7,4,7,0,0,1,8,5,6,7,5,1,9,9,3,5,0,7,
            5 };
        // int[] nums = {9,0,4,0,1,0,5,9,2,0,7};
        System.out.println(canJump(nums));
    }
    static boolean canJump(int[] nums) {
        int jump = 0, prev = 1, temp = 0, rCount = 0;
        boolean exit = false;
        if(nums.length == 1){
            return true;
        }
        else if (nums[0] == 0){
            return false;
        }
        for (int i = 0; jump < nums.length; i = jump) {
            if(jump >= nums.length-1) return true;  
            if (nums[i] == 0) {
                rCount = i+2;
                System.out.println("r "+ rCount);
                for (int k = prev; k < i; k++) {
                    System.out.println("k "+ k);
                    if (nums[temp] == 0) {
                        temp = nums[k];
                    }else{
                        temp = prev;
                    }
                    for (int j = prev; j < i; j = temp) {
                        if(nums[j] == 0) {
                            temp++;
                            prev++;
                            break;
                        }
                        temp += nums[j];
                        System.out.println("jump " + temp);
                        if (temp > jump) {
                            jump = temp;
                            i = jump;
                            exit = true;
                            break;
                        }
                    }
                    if(exit){
                        exit = false;   
                        System.out.println("Doneeeeeeeee");   
                        prev = rCount;               
                        break;
                    }
                }
                if(jump >= nums.length-1) return true;  
                System.out.println("prev" + prev   );
                System.out.println("flsesss");
                if (nums[i] == 0 && rCount > jump){    
                    return false;
                }
            } else {
                jump += nums[i];
                i = jump;
                System.out.println("fgfdgdfgdfgfd "+jump);
                prev = nums[jump+1];  
            }
        }

        System.out.println("j "+ jump);
        if (jump >= nums.length-1) {
            return true;
        } else {
            return false;
        }
    }
}