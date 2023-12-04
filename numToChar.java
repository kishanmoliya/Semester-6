// W.A.P.	to	convert	numbers	into	equivalent	characters	in	a	given	string.
// Input:	a2b3cd	Output:	abbcccd
// Input:	4az2b5c3af3g	Output:	aaaazbbcccccaaafggg

import java.util.ArrayList;

public class numToChar {
    static ArrayList arr = new ArrayList<>();
    public static void main(String[] args) {
        String input = "a2b3cd";

        for (int i = 0; i < input.length(); i++) {
            if (input.charAt(i) < 'a') {
                addChar(input.charAt(i), input.charAt(i + 1));
            } else {
                arr.add(input.charAt(i));
            }
        }

       System.out.println(arr);
    }

    static void addChar(int count, char c) {
        for (int i = 0; i < count - 1; i++) {
            arr.add(c);
        }
    }
}
