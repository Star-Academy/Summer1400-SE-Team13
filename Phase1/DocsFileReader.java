import java.io.*;
import java.util.*;

public class DocsFileReader {

    public DocsFileReader() {
    }

    public HashMap<Integer, String> readContent(String filePath) {
        HashMap<Integer, String> filesContents = new HashMap<>();
        File[] files = new File(filePath).listFiles();
        for (File file : files) {
            try {
                Scanner scanner = new Scanner(file);
                scanner.useDelimiter("\\Z");
                String fileContent = (scanner.next());
                scanner.close();
                filesContents.put(Integer.parseInt(file.getName()), fileContent);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }
        }
        return filesContents;
    }
}
