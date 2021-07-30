package src;

import java.io.*;
import java.util.*;

public class DocsFileReader {

    public DocsFileReader() {
    }

    public HashMap<Integer, String> readContent(String filePath) {
        HashMap<Integer, String> filesContents = new HashMap<>();
        try {
            File files = new File(filePath);
            for (File file : files.listFiles()) {
                Scanner scanner = new Scanner(file);
                scanner.useDelimiter("\\Z");
                String fileContent = scanner.next();
                scanner.close();
                filesContents.put(Integer.parseInt(file.getName()), fileContent);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return filesContents;
    }
}
