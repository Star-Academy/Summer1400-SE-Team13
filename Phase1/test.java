import java.util.Arrays;

public class test {
    public static void main(String[] args) {
        String[] str = { "-lalala", "+lalala", "lalala" };
        Arrays.sort(str);
        for (String s : str)
            System.out.println(s);
    }

}
