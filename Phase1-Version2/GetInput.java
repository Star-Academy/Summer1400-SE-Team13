import java.io.*;
import java.util.HashMap;
import java.util.*;

public class GetInput {
    private String mainPath;

    public GetInput(String path) {
        mainPath = path;
    }

    public HashMap<Integer, String> readContent() {
        HashMap<Integer, String> filesContents = new HashMap<>();
        int number = 0;
        for (File file : this.getFiles()) {
            try {
                Scanner scanner = new Scanner(file);
                StringBuilder content = new StringBuilder();
                while (scanner.hasNextLine()) {
                    content.append(" ").append(scanner.nextLine());
                }
                filesContents.put(number, content.toString().trim());
                scanner.close();
                number++;
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }
        
        }
        return filesContents;
    }

    public File[] getFiles() {
        return new File(mainPath).listFiles();
    }
    
}
