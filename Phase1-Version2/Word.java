import java.util.*;


public class Word {
    private ArrayList<Integer> docId;
    private String word;

    public Word(String word) {
        docId = new ArrayList<>();
        this.word = word;
    }

    public void addDoc(int ID) {
        docId.add(ID);
    }
    public ArrayList<Integer> getID() {
        return docId;
    }

    public String getWord() {
        return word;
    }


}