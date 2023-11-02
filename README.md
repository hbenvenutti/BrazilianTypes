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
2. [Tipos](./README.md#tipos)
    - [Cpf](./README.md#cpf)
        - [Propriedades](./README.md#propriedades)
        - [Métodos](./README.md#métodos)
        - [Como Usar](./README.md#como-usar)
3. [Contribuindo](./README.md#contribuindo)

<hr>

# Tipos
## Cpf

O tipo Cpf representa um número de CPF (Cadastro de Pessoas Físicas) válido.

### Propriedades

- **Mask**: Obtém o CPF formatado com a máscara (###.###.###-##).
- **Digits**: Obtém os dígitos do CPF.

### Métodos

- **Parse(string value)**: Converte uma string em um objeto Cpf.
- **TryParse(string value, out Cpf cpf)**: Tenta converter uma string em um objeto Cpf.
- **IsValid(string cpf)**: Verifica se um CPF é válido.
- **Generate()**: Gera um número de CPF válido.

### Como Usar

Para começar a usar a biblioteca BrazilianTypes, siga os passos abaixo:

1. Adicione uma referência ao projeto onde deseja usar a biblioteca.
2. Importe o namespace BrazilianTypes.Types.
3. Utilize os tipos e métodos conforme necessário.

Exemplo:

```csharp
using BrazilianTypes.Types;

string cpfString = "12345678901";
Cpf cpf = Cpf.Parse(cpfString);

string cpfMasked = cpf.Mask; // Retorna o CPF formatado com a máscara
string cpfDigits = cpf.Digits; // Retorna os dígitos do CPF
```

<hr>

# Contribuindo

Se encontrar algum problema ou tiver sugestões de melhorias, sinta-se à vontade 
para abrir uma issue ou enviar um pull request.
