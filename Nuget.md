# BrazilianTypes

A biblioteca BrazilianTypes fornece tipos e funcionalidades para trabalhar com
dados específicos do Brasil, como CPFs.

# Índice

1. [BrazilianTypes](./README.md#braziliantypes)
2. [Como Usar](./README.md#como-usar)
3. [Tipos](./README.md#tipos)
    - [CPF](./README.md#cpf)
    - [CEP](./README.md#zipcode---cep)
4. [Contribuindo](./README.md#contribuindo)

# Como Usar

Para começar a usar a biblioteca BrazilianTypes, siga os passos abaixo:

1. Adicione uma referência ao projeto onde deseja usar a biblioteca.
2. Importe o namespace BrazilianTypes.Types.
3. Utilize os tipos e métodos conforme necessário.

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

# Contribuindo

Se encontrar algum problema ou tiver sugestões de melhorias, sinta-se à vontade
para abrir uma issue ou enviar um pull request.
