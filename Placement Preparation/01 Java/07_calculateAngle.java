import java.util.Scanner;

public class calculateAngle {
    public static void main(String[] args) {
         Scanner sc = new Scanner(System.in);
        System.out.print("Enter the Hour: ");
        int h  = sc.nextInt();
        System.out.print("Enter the Minute: ");
        int m  = sc.nextInt();

        double hour = (h * 60 + m) / 2;
        double min = m * 6;

        double angle = Math.abs(hour - min);

        if(angle <= 180){
            System.out.println(angle);
        }else{
            System.out.println(360 - angle);
        }
    }
}