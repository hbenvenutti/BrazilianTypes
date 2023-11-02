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

# Índice

1. [BrazilianTypes](./README.md#braziliantypes)
2. [Como Usar](./README.md#como-usar)
3. [Tipos](./README.md#tipos)
    - [CPF](./README.md#cpf)
    - [CEP](./README.md#zipcode---cep)
    - [UF](./README.md#uf)
4. [Contribuindo](./README.md#contribuindo)

<hr>

# Como Usar

Para começar a usar a biblioteca BrazilianTypes, siga os passos abaixo:

1. Adicione uma referência ao projeto onde deseja usar a biblioteca.
2. Importe o namespace BrazilianTypes.Types.
3. Utilize os tipos e métodos conforme necessário.

<hr>

# Tipos
## CPF

O tipo Cpf representa um número de CPF (Cadastro de Pessoas Físicas) válido.

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

- **Mask**: Obtém o CPF formatado com a máscara (###.###.###-##).

```csharp 
string mask = cpf.Mask; // 123.456.789-01
```

- **Digits**: Obtém os dígitos do CPF.

```csharp 
string digits = cpf.Digits; // 01
```

### Métodos

- **TryParse**: Tenta converter uma string em um objeto Cpf.

```csharp 
bool isValid = Cpf.TryParse(string value, out Cpf cpf)
```

- **Generate**: Gera um número de CPF válido.

```csharp 
Cpf cpf = Cpf.Generate()
```

## ZipCode - CEP

O tipo ZipCode representa um número de CEP (Código de Endereçamento Postal) Brasileiro

### Exemplo:

```csharp
using BrazilianTypes.Types;

// conversão implicita de string para CEP (sem máscara)
ZipCode cep = "12345678"; 
ZipCode cep = "12345-678";

// conversão implicita de CEP para string
string str = cep;  
```

### Propriedades

- **Mask**: Obtém o CEP formatado com a máscara (#####-###).
```csharp
ZipCode cep = "12345678";
 string cepMasked = cep.Mask; // Retorna o CEP formatado com a máscara
```

### Métodos

- **TryParse**: Tenta converter uma string em um objeto ZipCode.

```csharp
 bool isValid = ZipCode.TryParse(string value, out ZipCode zipCode)
```

## UF

O tipo Uf representa uma Unidade Federativa do Brasil.

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

- **TryParse**: Tenta converter uma string em um objeto Uf.

```csharp
 bool isValid = Uf.TryParse(string value, out Uf uf)
```

<hr>

# Contribuindo

Se encontrar algum problema ou tiver sugestões de melhorias, sinta-se à vontade 
para abrir uma issue ou enviar um pull request.
