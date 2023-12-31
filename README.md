# BrazilianTypes
![Static Badge](https://img.shields.io/badge/.NET-8-blue)
![Nuget](https://img.shields.io/nuget/v/BrazilianTypes)
![GitHub License](https://img.shields.io/github/license/hbenvenutti/BrazilianTypes)
![GitHub repo size](https://img.shields.io/github/repo-size/hbenvenutti/BrazilianTypes)
[![built with Codeium](https://codeium.com/badges/main)](https://codeium.com/badges/main)

---

A biblioteca BrazilianTypes fornece tipos e funcionalidades para trabalhar com
dados específicos do Brasil, como CPFs.

# Índice

1. [BrazilianTypes](#braziliantypes)
2. [Como Usar](#como-usar)
3. [Interfaces](#interfaces)
   - [IType](#itypet)
   - [IMaskedType](#imaskedtype)
   - [IGenerable](#igenerablet)
   - [ISpecification](#ispecificationtcode-ttype)
4. [Tipos](#tipos)
   - [CPF](#cpf--itypecpf-imaskedtype-igenerablecpf)
   - [CNPJ](#cnpj--itypecnpj-imaskedtype-igenerablecnpj)
   - [CEP](#zipcode--itypezipcode-imaskedtype-igenerablezipcode)
   - [UF](#uf--itypeuf)
   - [Phone](#phone--itypephone-imaskedtype)
   - [Text](#text--itypetext)
   - [Name](#name--itypename)
   - [Email](#email--itypeemail)
5. [Contribuindo](#contribuindo)

---

# Como Usar

Para começar a usar a biblioteca BrazilianTypes, siga os passos abaixo:

1. Adicione uma referência ao projeto onde deseja usar a biblioteca.
2. Importe o namespace `BrazilianTypes.Types` ou `BrazilianTypes.Interfaces`.
3. Utilize os tipos e métodos conforme necessário.

**Observações**
- Os tipos são `structs`, portanto, são tipos por valor.
- Todos os tipos possuem `implicit operators` para conversão de `string` para o tipo.
- Os construtores dos tipos são privados, portanto, não é possível instanciá-los.
- Ao passar uma `string` inválida para o tipo, uma `exception` será lançada.
- Para validar se uma `string` pode ser usada por um tipo, utilize o método `TryParse`.
- Se você quiser criar tipos personalizados, basta criar uma `struct` que
  implemente as `interfaces` da biblioteca.

> Assim, você pode criar tipos como `Password` e `Username` que respeitam os padrões
usados na lib. Criando as validações necessárias para a sua necessidade.

Exemplo:

```c#
 public class User 
 {
    string Name { get; set;}
    Cpf Cpf { get; set; }
    Password Password { get; set; }
    ZipCode Cep { get; set; }
    Phone Phone { get; set; }
    Uf Uf { get; set; }
    Cnpj CompanyCnpj { get; set; }
     
     public User(
         string name,
         string cpf, 
         string cep, 
         string phone, 
         string uf, 
         string companyCnpj,
         string password
      )
     {
        Name = name;
        Cpf = cpf;
        Cep = cep;
        Phone = phone;
        Uf = uf;
        CompanyCnpj = companyCnpj;
        Password = password;
     }
 }
 
readonly struct Password : IType<Password>
{
    <...> // resto do código   
}
```

---

# Data Annotations

Pode-se usar data annotations para validar os objetos.

- Todos os tipos tem anotações.

```csharp
public class User 
{
    [Required]
    [Cpf(ErrorCode = 400)]
    string Cpf { get; set; }
     
    [ZipCode]
    string ZipCode { get; set; }
}
```

---

# Interfaces

## `IType<T>`

A interface `IType<T>` define um tipo genérico com capacidades de parse.

```csharp
public interface IType<T>
{
    static abstract string ErrorMessage { get; }

    static abstract bool TryParse(string value, out T type);
}
```

## `IMaskedType`

A interface `IMaskedType` define um tipo com aplicação de máscara.

```csharp
public interface IMaskedType
{
    string Mask { get; }
}

```

## `IGenerable<T>`

A interface `IGenerable<T>` define um tipo que pode ser gerado aleatoriamente.

```csharp
public interface IGenerable<out T>
{
    static abstract T Generate();
}

```

## `ISecurityMaskedType`

Interface para tipos que precisam esconder parte de seus dados.

```csharp
public interface ISecurityMaskedType
{
    string SecurityMask { get; }
}
```

## `ISpecification<TCode, TType>`

A interface `ISpecification` define uma especifacação para validação de dados.

```csharp
public interface ISpecification<TCode, in TType>
    where TCode : struct
    where TType : struct
{
    TCode Code { get; protected set; }

    ICollection<string> ErrorMessages { get; init; }

    bool IsSatisfiedBy(TType data);
}
```

- `Code`: Código de erro personalizado da sua aplicação.
- `ErrorMessages`: Mensagens de erro personalizadas da sua aplicação.
- `IsSatisfiedBy`: Método que valida os dados.
- `TCode`: Tipo do código de erro. Deve ser um tipo de valor.
- `TType`: Tipo do dado a ser validado. Deve ser um tipo de valor.

---

# Tipos

## `Cpf : IType<Cpf>, IMaskedType, IGenerable<Cpf>`

O tipo `Cpf` representa um número de CPF (Cadastro de Pessoas Físicas) válido.

### Exemplo:

```csharp
using BrazilianTypes.Types;

// conversão implicita de string para CPF (sem máscara)
Cpf cpf = "12345678901"; 
Cpf cpf = "123.456.789-01"; // 12345678901

// conversão implicita de CPF para string
string str = cpf;  // 12345678901
```

### Propriedades

- `Mask`: Obtém o CPF formatado com a máscara (###.###.###-##).

```csharp 
string mask = cpf.Mask; // 123.456.789-01
```

- `SecurityMask`: Obtém o CPF formatado com a máscara (\*\*\*.###.###-\*\*).

```csharp 
string mask = cpf.SecurityMask; // ***.456.789-**
```

- `Digits`: Obtém os dígitos do CPF.

```csharp 
string digits = cpf.Digits; // 01
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto `Cpf`.

```csharp 
bool isValid = Cpf.TryParse(string value, out Cpf cpf)
```

- `Generate`: Gera um número de CPF válido.

```csharp 
Cpf cpf = Cpf.Generate()
```

---

## `Cnpj : IType<Cnpj>, IMaskedType, IGenerable<Cnpj>`

O tipo `Cnpj` representa um número de CNPJ (Cadastro Nacional de Pessoa Jurídica)

### Exemplo:

```csharp
using BrazilianTypes.Types;

// conversão implicita de string para CPF (sem máscara)
Cnpj cnpj = "12345678000101; 
Cnpj cnpj = "12.345.678/0001-01"; // 12345678000101; 

// conversão implicita de CNPJ para string
string str = cnpj;  // 12345678000101; 
```

### Propriedades

- `Mask`: Obtém o CNPJ formatado com a máscara (##.###.###/####-##).

```csharp 
string mask = cnpj.Mask; // 12.345.678/0001-01
```

- `SecurityMask`: Obtém o CNPJ formatado com a máscara 
(\*\*.###.###/\*\*\*\*-\*\*).

```csharp 
string mask = cnpj.SecurityMask; // **.345.678/****-**
```

- `Digits`: Obtém os dígitos do CNPJ.

```csharp 
string digits = cnpj.Digits; // 01
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto `Cnpj`.

```csharp 
bool isValid = Cnpj.TryParse(string value, out Cnpj cnpj)
```

- `Generate`: Gera um número de CNPJ válido.

```csharp 
Cnpj cnpj = Cnpj.Generate()
```

---

## `ZipCode : IType<ZipCode>, IMaskedType, IGenerable<ZipCode>`

O tipo `ZipCode` representa um número de CEP (Código de Endereçamento Postal)
Brasileiro.

### Exemplo:

```csharp
using BrazilianTypes.Types;

// conversão implicita de string para CEP (sem máscara)
ZipCode cep = "12345678";  // 12345678
ZipCode cep = "12345-678"; // 12345678

// conversão implicita de CEP para string
string str = cep;  
```

### Propriedades

- `Mask`: Obtém o CEP formatado com a máscara (#####-###).
```csharp
 string cepMasked = cep.Mask; // 12345-678
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto `ZipCode`.

```csharp
 bool isValid = ZipCode.TryParse(string value, out ZipCode zipCode)
```

- `Generate`: Gera um CEP válido.

```csharp 
ZipCode cep = ZipCode.Generate()
```

---

## `UF : IType<Uf>`

O tipo `Uf` representa uma Unidade Federativa do Brasil.

### Exemplo:

```csharp
using BrazilianTypes.Types;

// conversão implicita de string para UF
Uf uf = "rs"; // RS
Uf uf = "RS";

// conversão implicita de UF para string
string str = uf;  
```
### Métodos

- `TryParse`: Tenta converter uma string em um objeto `Uf`.

```csharp
 bool isValid = Uf.TryParse(string value, out Uf uf)
```
---

## `Phone : IType<Phone>, IMaskedType`

O tipo `Phone` representa um número de telefone brasileiro.

### Exemplo:

```csharp
using BrazilianTypes.Types;

// conversão implicita de string para Phone
Phone phone = "(51) 99999-8888"; // 51999998888

Phone phone = "51999998888"; // 51999998888

Phone phone = "(51) 3333-4444"; // 5133334444
Phone phone = "5133334444"; // 5133334444

// conversão implicita de Phone para string
string str = phone;  
```

### Propriedades

- `Mask`: Obtém o Telefone formatado com a máscara ((##) #####-###).
```csharp
 string mobile = phone.Mask; // (51) 99999-8888
 string landline = phone.Mask; // (51) 3333-4444
```

- `SecurityMask`: Obtém o Phone formatado com a máscara ((##) \*\*\*\*-####).

```csharp 
string mask = phone.SecurityMask; // (51) ****-8888
```

- `IsMobile`: Obtém um valor que indica se o telefone é móvel.
    
```csharp
 bool isMobile = phone.IsMobile; // true
```

- `Ddd`: Obtém o DDD do telefone.
```csharp
 string ddd = phone.Ddd; // 51
```

- `Number`: Obtém o número sem o DDD do telefone.
```csharp
 string number = phone.Number; // 999998888
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto `Phone`.

```csharp
 bool isValid = Phone.TryParse(string value, out Phone phone)
```

- `FromSplit`: Cria um objeto `Phone` a partir de um DDD e um número de telefone.

```csharp
 Phone phone = Phone.FromSplit(string ddd, string number)
```

---

## `Text : IType<Text>`

O tipo `Text` representa um texto que não pode ser nulo ou vazio.

### Exemplo:

```csharp
using BrazilianTypes.Types;

Text text = "Hello World"; // "Hello World"

Text text = " Hello World "; // "Hello World"

Text text = " "; // throw exception

Text text = ""; // throw exception

Text text = null; // throw exception
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto `Text`.

```csharp
 bool isValid = Text.TryParse(string value, out Text text)
```

---

## `Name : IType<Name>`

O tipo `Name` representa um nome que contém apenas letras e não pode ser nulo 
ou vazio.

### Exemplo:

```csharp
using BrazilianTypes.Types;

Name name = "John Doe"; // "John Doe"

Name name = " John Doe "; // "John Doe"

Name name = "João"; // João
Name name = "Júlia"; // Júlia

Name name = " "; // throw exception

Name name = ""; // throw exception

Name name = null; // throw exception
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto `Name`.

```csharp
 bool isValid = Name.TryParse(string value, out Name name)
```

---

## `Email : IType<Email>`

O tipo `Email` representa um endereço de e-mail.

### Exemplo:

```csharp
using BrazilianTypes.Types;

Email email = "foobar@gmail.com"; // "foobar@gmail.com"

Email email = "FOOBAR@GMAIL.COM"; // "foobar@gmail.com"
Email email = " FOOBAR@GMAIL.COM "; // "foobar@gmail.com"

Email email = "foobar@gmail"; // "throw exception"
Email email = ".foobar@gmail.com"; // "throw exception"
Email email = "foobar.gmail"; // "throw exception"
Email email = "foobar@gmail."; // "throw exception"
Email email = "foobar@gmail..com"; // "throw exception"
Email email = "foobar.gmail.com"; // "throw exception"
Email email = "foobar@.gmail.com"; // "throw exception"
Email email = "@gmail.com"; // "throw exception"
Email email = "@"; // "throw exception"
Email email = "foobar"; // "throw exception"
Email email = "foobar@"; // "throw exception"

Email email = " "; // throw exception
Email email = ""; // throw exception
Email email = null; // throw exception
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto `Email`.

```csharp
 bool isValid = Email.TryParse(string value, out Email email)
```

---

# Contribuindo

Se encontrar algum problema ou tiver sugestões de melhorias, sinta-se à vontade
para abrir uma issue ou enviar um pull request.
