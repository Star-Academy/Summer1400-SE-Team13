import java.util.*;

public class Main {
    public static void main(String[] args) {
        GetInput getInput = new GetInput("C:/Users/ASUS/Downloads/SampleEnglishData/EnglishData");
        HashMap<Integer, String> hashMap = getInput.readContent();
        int i = 0;
        
        for (int key : hashMap.keySet()) {
            System.out.println("key: " + key + "value: " + hashMap.get(key));
            i++;
            if(i == 5)
                break;
        }
    }
    
}
