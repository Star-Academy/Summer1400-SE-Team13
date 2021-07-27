import java.io.*;
import java.util.*;

public class DocsFileReader {
    private final String mainPath;

    public DocsFileReader(String path) {
        mainPath = path;
    }

    public HashMap<Integer, String> readContent() {
        HashMap<Integer, String> filesContents = new HashMap<>();
        File[] files = new File(mainPath).listFiles();
        for (File file : files) {
            try {
                Scanner scanner = new Scanner(file);
                StringBuilder content = new StringBuilder();
                while (scanner.hasNextLine()) {
                    content.append(" ").append(scanner.nextLine());
                }
                filesContents.put(Integer.parseInt(file.getName()), content.toString().trim());
                scanner.close();
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }
        }
        return filesContents;
    }
}
