# Gunit

**Gunit** pronounced ***Gunn-itt*** is [Goblinfactory's](http://www.goblinfactory.co.uk) low ceremony, open source, zero dependency, 
cross platform (specifically mobile android) testing library. Gunit includes a fluent `Verify` object comparer that provides comprehensive object verification in mobile applications and libraries
 or anywhere where other libraries like [fluentassertions]() cannot be used due to dependancy restrictions.

The package also includes `Ensure` debugging-friendly replacement for NUnit's `Assert.That`.

### Getting Started

1. Install package

```
> Install-package Verify
```

2. On global test start, tell Verify what platform you're using by wiring up the default platform Assert. Example below wired us Nunit.

```
Gunit.Init(Assert.Fail);
``` 

3. **start verifying...**


```
  var c1 = new Cat(1,"Fred", Kittens = new [] { "Slippers", "Buttons" });
  var c2 = new Cat(1,"Fred", Kittens = new [] { "Slippers", "Buttons" });

  Verify.AreSame(c1,c2);
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
 // or configure when initialising 
 Gunit.Init(new Config { ToleranceMs = 200, MaxDepth = 10 }, m=> Assert.Fail(m));
 ```

 [More examples](docs/more-examples.md)
