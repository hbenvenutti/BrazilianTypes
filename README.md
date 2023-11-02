# BrazilianTypes

A biblioteca BrazilianTypes fornece tipos e funcionalidades para trabalhar com 
dados específicos do Brasil, como CPFs.

<div id="header" >
	<img
		alt="GitHub release (latest by date)"
		src="https://img.shields.io/github/v/release/hbenvenutti/BrazilianTypes?style=plastic"
		title="Latest Release"
	/>
	<img
		alt="GitHub last commit (feature)"
		src="https://img.shields.io/github/last-commit/hbenvenutti/BrazilianTypes/feature?label=last%20commit&style=plastic"
		title="Last Commit on feature branch"
	/>
	<img
		alt="GitHub contributors"
		src="https://img.shields.io/github/contributors/hbenvenutti/BrazilianTypes?style=plastic"
		title="Contributors"
	>
</div>

<div>
	<img
		alt="GitHub commit activity (feature)"
		src="https://img.shields.io/github/commit-activity/w/hbenvenutti/BrazilianTypes/feature?style=plastic"
	>
	<img
		alt="GitHub forks"
		src="https://img.shields.io/github/forks/hbenvenutti/BrazilianTypes?style=plastic"
	>
	<img
		alt="GitHub Repo stars"
		src="https://img.shields.io/github/stars/hbenvenutti/BrazilianTypes?style=plastic"
	>
	<img
		alt="GitHub watchers"
		src="https://img.shields.io/github/watchers/hbenvenutti/BrazilianTypes?style=plastic"
	>
	<img
		alt="GitHub pull requests"
		src="https://img.shields.io/github/issues-pr/hbenvenutti/BrazilianTypes?style=plastic"
	>
	<img
		alt="GitHub closed pull requests"
		src="https://img.shields.io/github/issues-pr-closed/hbenvenutti/BrazilianTypes?style=plastic"
	>
	<img
		alt="GitHub code size in bytes"
		src="https://img.shields.io/github/languages/code-size/hbenvenutti/BrazilianTypes?style=plastic"
	>
</div>

---

# Índice

1. [BrazilianTypes](./README.md#braziliantypes)
2. [Como Usar](./README.md#como-usar)
3. [Interfaces](./README.md#interfaces)
   - [IType](./README.md#itypet)
   - [IMaskedType](./README.md#imaskedtype)
   - [IGenerable](./README.md#igenerablet)
4. [Tipos](./README.md#tipos)
    - [CPF](./README.md#cpf--itypecpf-imaskedtype-igenerablecpf)
    - [CNPJ](./README.md#cnpj--itypecnpj-imaskedtype-igenerablecnpj)
    - [CEP](./README.md#zipcode--itypezipcode-imaskedtype-igenerablezipcode)
    - [UF](./README.md#uf--itypeuf)
    - [Phone](./README.md#phone--itypeuf-imaskedtype)
5. [Contribuindo](./README.md#contribuindo)

<hr>

# Como Usar

Para começar a usar a biblioteca BrazilianTypes, siga os passos abaixo:

1. Adicione uma referência ao projeto onde deseja usar a biblioteca.
2. Importe o namespace BrazilianTypes.Types.
3. Utilize os tipos e métodos conforme necessário.

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

- `Digits`: Obtém os dígitos do CPF.

```csharp 
string digits = cpf.Digits; // 01
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto Cpf.

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
string mask = cnpj.Mask; // "12.345.678/0001-01"
```

- `Digits`: Obtém os dígitos do CNPJ.

```csharp 
string digits = cnpj.Digits; // 01
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto Cnpj.

```csharp 
bool isValid = Cpf.TryParse(string value, out Cnpj cnpj)
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

- `TryParse`: Tenta converter uma string em um objeto ZipCode.

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

- `TryParse`: Tenta converter uma string em um objeto Uf.

```csharp
 bool isValid = Uf.TryParse(string value, out Uf uf)
```
---

## `Phone : IType<Uf>, IMaskedType`

O tipo `Phone` representa um número de telefone brasileiro.

### Exemplo:

```csharp
using BrazilianTypes.Types;

// conversão implicita de string para UF
Phone phone = "(51) 99999-8888"; // 51999998888

Phone phone = "51999998888"; // 51999998888

Phone phone = "(51) 3333-4444"; // 5133334444
Phone phone = "5133334444"; // 5133334444

// conversão implicita de UF para string
string str = phone;  
```

### Propriedades

- `Mask`: Obtém o Telefone formatado com a máscara ((##) #####-###).
```csharp
 string mobile = phone.Mask; // (51) 99999-8888
 string landline = phone.Mask; // (51) 3333-4444
```

- `IsMobile`: Obtém um valor que indica se o telefone é móvel.
```csharp
 bool isMobile = phone.IsMobile; // true
```

- `Ddd`: Obtém o DDD do telefone.
```csharp
 string ddd = phone.Ddd; // 51
```

### Métodos

- `TryParse`: Tenta converter uma string em um objeto Phone.

```csharp
 bool isValid = Phone.TryParse(string value, out Phone phone)
```

- `FromSplit`: Cria um objeto Phone a partir de um DDD e um número de telefone.

```csharp
 Phone phone = Phone.FromSplit(string ddd, string number)
```

---

# Contribuindo

Se encontrar algum problema ou tiver sugestões de melhorias, sinta-se à vontade 
para abrir uma issue ou enviar um pull request.
