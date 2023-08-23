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