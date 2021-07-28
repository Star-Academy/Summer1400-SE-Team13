package test;

import src.*;
import java.util.*;
import static org.junit.Assert.*;
import org.junit.Test;

public class DocsFileReaderTest {

    @Test
    public void testFileReader() {
        DocsFileReader docsFileReader = new DocsFileReader();
        String docContentExpected = "Hello World.";
        Integer docIDExpected = 1;
        HashMap<Integer, String> expectedValue = new HashMap<>();
        expectedValue.put(docIDExpected, docContentExpected);
        final String fileAddress = "Phase1/test/SampleFolder";
        HashMap<Integer, String> actualValue = docsFileReader.readContent(fileAddress);
        assertEquals(expectedValue, actualValue);
    }
}
