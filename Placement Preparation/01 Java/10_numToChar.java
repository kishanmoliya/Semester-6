
// W.A.P.	to	convert	numbers	into	equivalent	characters	in	a	given	string.
// Input:	a2b3cd	Output:	abbcccd
// Input:	4az2b5c3af3g	Output:	aaaazbbcccccaaafggg
import java.util.ArrayList;

public class numToChar {
    public static void main(String[] args) {
        String input = "4az2b5c3af3g";

        for (int i = 0; i < input.length(); i++) {
            if (Character.isDigit(input.charAt(i))) {
                for (int j = 0; j < Character.getNumericValue(input.charAt(i)) - 1; j++) {
                    System.out.print(input.charAt(i+1));
                }
            } else {
                System.out.print(input.charAt(i));
            }
        }
    }
}
