## Gunit - More Examples

[Home](../README.md)

### Verify


```
  var c1 = new Cat(1,"Fred", Kittens = new [] { "Slippers", "Buttons" });
  var c2 = new Cat(1,"Fred", Kittens = new [] { "Slippers", "Buttons" });

  Verify.AreSame(c1,c2);
  // or
  c1.VerifySame(c2);
```
**Breadcrumb nested property testing**

If a deeply nested property on an object is different between two objects, Verify will report the difference with a breadcrumb trail to the child property.

```
  c2.Kittens["Slippers"].Age = 10;

  // differences collection is not implemented yet!
  // ----------------------------------------------
  c1.Differences(c2).Ensure( 
        d=> d.Length    == 1,
        d=> d[0].Crumb  = "Cat.Kittens.[1].Age",
        d=> d[0].Error     = "Expected 0, but found 10."
    );

  Ensure.Throws<AssertionException>(
    c1.VerifySameAs(c2);
  );

``` 

### Q: Why Ensure?

Nunit already has a fluent `Assert.That` syntax, why yet another one?

using **NUnit Assert**
```
[Test]
public void AssertThat()
{
    Cat cat = new Cat(4,"Fred");
    Assert.That(cat != null);
    Assert.That(cat.Name == "Fred");
    Assert.That(cat.Age>5);
}
```

**results in**

Expected true, but was false.

<img src='notes/assert-that1.JPG' width=350px/>

When using **Ensure**

```
[Test]
public void Ensure()
{
    Cat cat = new Cat(4, "Fred");
    cat.Ensure(
        c => c != null,
        c => c.Name == "Fred",
        c => c.Age > 5
    );
}

```

**results in**

You get to see the line of code, from the condition that failed.

<img src='notes/ensure1.JPG' width=350px/>

Lastly, it can be much easier to read at a quick glance and understand the intent. (scan) In the example above, the asserts I used

```
  c1.Differences(c2).Ensure( 
        d=> d.Length    == 1,
        d=> d[0].Crumb  = "Cat.Kittens.[1].Age",
        d=> d[0].Error  = "Expected 0, but found 10."
    );
```

Would have to be written as follows using Nunit's Assert.
```
var differences = c1.Differences(c2);
Assert.That(d.Length, Is.EqualTo(1));
Assert.Contains(d.Crumb, "Cat.Kittens.[1].Age");
Assert.That(d.Error, Is.EqualTo("Cat.Kittens.[1].Age"));
```

#### Reminder
Lastly, a reminder that this library is not meant as a replacement for FluentAssertions (the best tool available in my opinion), but currently not usable with Droid projects.