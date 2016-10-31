# Gunit

**Gunit** pronounced ***Gunn-itt*** . A (good enough) low ceremony, open source, zero dependency, 
cross platform (specifically mobile android) testing library. Gunit includes a fluent `Verify` object comparer that provides 
object property equality verification in mobile applications and libraries,
 or anywhere where other libraries like [fluentassertions]() cannot be used due to dependancy restrictions.

The package also includes `Ensure`, a debugging-friendly alernative to NUnit's `Assert.That`.

### Getting Started

Install package

```
> Install-package Verify
```


**start verifying...**


```
  var c1 = new Cat(1,"Fred", Kittens = new [] { "Slippers", "Buttons" });
  var c2 = new Cat(1,"Fred", Kittens = new [] { "Slippers", "Buttons" });

  Verify.VerifySame(c1,c2);
  // or
  c1.VerifySame(c2);

  // Deliberately change a property
  // ------------------------------
  c2.Kittens[2].Age = 20;

  // Confirm child property difference is detected
  // ---------------------------------------------
  Ensure.Throws<CompareException>(c1.VerifySame(c2)); 

```
 
 Verify will by default treverse down to 5 levels deep. This can be configured during initialisation, or passed in as a parameter.

 ```
 c1.VerifySame(c2, MaxDepth = 10);
 ```

 Default DateTime tolerance, when comparing dates, is set to 200ms, to support lazy developers (like me) 
 who often don't have time to refactor customer's code to inject a DateTime provider into all classes under test.  This can also be configured globally or once per test.

 ```
 c1.VerifySame(c2, ToleranceMs = 200);
 // or configure globally
 Gunit.Config = new Config() { ToleranceMs = 200, MaxDepth = 10 };
 ```

 [More examples](docs/more-examples.md)
