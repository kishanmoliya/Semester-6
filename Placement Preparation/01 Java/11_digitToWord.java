// Accept	a	number	between	0	and	99	from	the	user	and	display	the	value	in	words. For	example,
// entering	25	should	display	“Twenty	Five”.	Appropriate	error	message	should	be	displayed	if	the
// value	entered	by	the	user	is	out	of	permissible	range.

import java.util.Scanner;

class digitToWord{
    public static void main(String[] args) {
        String[] word = {"Zero","One","Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten","Eleven","Twelve","Thirteen","Forteen","Fifteen","Sixteen","Seventeen","Eighteen","nineteen","Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninety","Hundred","Thousand"};
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter the number: ");
        int n = sc.nextInt();

        if(n < 21){
            System.out.println(word[n]);
        }else{
            System.out.println(word[(n/10)+18] + " " + word[n%10]);
        }
    }
}