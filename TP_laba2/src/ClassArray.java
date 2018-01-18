import java.util.ArrayList;

public class ClassArray<T> {
	private ArrayList<T> places;
	private T defaultValue;

	public ClassArray(int size, T defVal) {
		defaultValue = null;
		places = new ArrayList<T>();
		for (int i = 0; i < size; i++) {
			places.add(i, defVal);
		}
	}

	public int add(ClassArray<T> p, T crocodile) {
		for (int i = 0; i < p.places.size(); i++) {
			if (p.checkFreePlace(i)) {
				p.places.set(i, crocodile);
				return i;
			}
		}
		return -1;
	}

	private boolean checkFreePlace(int index) {
		if (index < 0 || index > places.size()) {
			return false;
		}
		if (places.get(index) == null) {
			return true;
		}
		if (places.get(index).equals(defaultValue)) {
			return true;
		}
		return false;
	}

	public T dec(ClassArray<T> p, int index) {
		if (!p.checkFreePlace(index)) {
			T crocodile = p.places.get(index);
			p.places.set(index, null);
			return crocodile;
		}
		return p.defaultValue;
	}

	public T getObject(int ind) {
		if (ind > -1 && ind < places.size()) {
			return places.get(ind);
		}
		return defaultValue;
	}
}
