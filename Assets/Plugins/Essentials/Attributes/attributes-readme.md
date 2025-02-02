# Flags
Used to add multi-select flags capability for an enum inspector field. Example:
``` csharp
// definition
public enum Options {
	Option1 = 1 << 0,
	Option2 = 1 << 1,
	Option3 = 1 << 2,
	Option4 = 1 << 3
}

// using
[Flags, SerializeField] private Options _options;
```
![image](https://github.com/user-attachments/assets/e02e07f2-4a87-4d84-82bc-8ded2fc6a41c)

# MinMax
Used to replace 'x' and 'y' in Vector2 and Vector2Int names with Min and Max respectively. Also constrains values ​​so that Max is never less than Min. Example:
``` csharp
[MinMax, SerializeField] private Vector2 _floatRange;
[MinMax, SerializeField] private Vector2Int _intRange;
```

![image](https://github.com/user-attachments/assets/e8318d69-e5c6-41d1-8747-979a38a9e91d)

# NotNull
Used to display empty or missing references of the ObjectReference and ExposedReference categories. Also check ManagedReference on 2021.2 and above. Additionally checks if string field is empty. Example:
``` csharp
[NotNull, SerializeField] private Rigidbody2D _rigidbody;
[NotNull, SerializeField] private string _name;
[NotNull, SerializeField] private GameObject _prefab;
[NotNull, SerializeField] private ScriptableObject _data;
[NotNull, SerializeField] private Text _uiText;
```

![image](https://github.com/user-attachments/assets/a98453f4-df06-4e4c-9473-4961ade06ca4)

# Preview
Used to preview images directly in the inspector. The preview is hidden if the link is empty. Can be combined with the NotNull attribute. Example:
``` csharp
[Preview, SerializeField] private Sprite _sprite;
[Preview, SerializeField] private Texture _texture;
[Preview, SerializeField] private Texture2D _texture2D;
```

![image](https://github.com/user-attachments/assets/717915cc-f474-4bb0-93a6-d1468f49310d)

# RangeSlider
Used to create a range of values ​​within the constraint range for Vector2 and Vector2Int fields. Example:
``` csharp
[RangeSlider(0f, 100f), SerializeField] private Vector2 _floatSlider = new Vector2(17f, 34f);
[RangeSlider(0, 100), SerializeField] private Vector2Int _intSlider = new Vector2Int(30, 90);
```

![image](https://github.com/user-attachments/assets/46f6154c-92d4-417e-9dc4-153692a853c5)

# ReadOnly
Used to prohibit editing of fields in the inspector. Example:
``` csharp
[SerializeField] private float _editableField;
[ReadOnly, SerializeField] private float _readOnlyField;
```

![image](https://github.com/user-attachments/assets/65dfdbb0-e60a-434a-8693-9312bee560ff)

# ShowIf
Used to hide and show certain fields in the inspector depending on conditions. The condition can be a bool field, property or method. Example:
``` csharp
[SerializeField] private bool _boolFlag;

[ShowIf(nameof(_boolFlag)), SerializeField] private int _fieldDepentField;
[ShowIf(nameof(BoolMethod)), SerializeField] private int _methodDepentField;
[ShowIf(nameof(BoolProperty)), SerializeField] private int _propertyDepentField;

private bool BoolProperty => _boolFlag;

private bool BoolMethod() {
	return _boolFlag;
}
```

![image](https://github.com/user-attachments/assets/234baf89-1588-4200-aabd-f050437875e9)
