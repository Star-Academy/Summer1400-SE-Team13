import java.io.*;
import java.util.HashMap;
import java.util.*;

public class DocsFileReader {
    private String mainPath;

    public DocsFileReader(String path) {
        mainPath = path;
    }

    public HashMap<Integer, String> readContent() {
        HashMap<Integer, String> filesContents = new HashMap<>();
        for (File file : this.getFiles()) {
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

    public File[] getFiles() {
        return new File(mainPath).listFiles();
    }
}
