package test;

import src.*;
import java.util.*;
import static org.junit.jupiter.api.Assertions.assertEquals;
import org.junit.jupiter.api.Test;

public class DocsFileReaderTest {

    @Test
    public void testFileReader() {
        DocsFileReader docsFileReader = new DocsFileReader();
        String docContentExpected = "Hello World.";
        Integer docIDExpected = 1;
        HashMap<Integer, String> expectedValue = new HashMap<>();
        expectedValue.put(docIDExpected, docContentExpected);
        final String fileAddress = "C:/Users/ASUS/Desktop/Summer1400-SE-Team13/Summer1400-SE-Team13/Phase1/test/SampleFolder/1";
        HashMap<Integer, String> actualValue = docsFileReader.readContent(fileAddress);
        assertEquals(expectedValue, actualValue);
    }
}
