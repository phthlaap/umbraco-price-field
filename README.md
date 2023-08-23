# Umbraco Price Field

### Features

- This package will add a editor property in price format.
- Provide a function to render the price field to HTML.

### How to use

```
@{
	dynamic dataType = Model.ContentType.GetPropertyType("productPrice").DataType;
	dynamic value = Model.Value("productPrice");
}
@PriceFieldExtensions.Format(value, dataType)
```

### Supporting organizations

- [Kyanon Digital](https://kyanon.digital/) willing allow us create open source software to support the community in working hours..