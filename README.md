# Sistema de Cadastro de Inteligências Artificiais (Projeto IA)

Aplicação desenvolvida como projeto do curso Técnico em Desenvolvimento de Sistemas da Etec de Peruíbe.  
O sistema permite administrar o registro de **Inteligências Artificiais (IAs)**, seus **fabricantes** e **categorias**, utilizando banco de dados relacional e validações de integridade. [attached_file:49]

## 🎯 Objetivo

- Cadastrar e gerenciar IAs em um banco de dados estruturado.  
- Vincular cada IA a um **fabricante** e a uma **categoria** válidos.  
- Facilitar a organização, consulta e manutenção das informações por meio de uma interface gráfica simples. [attached_file:49]

## 🧩 Funcionalidades

### 1. Cadastro de IA
- Tela inicial de cadastro apresentada após a tela de carregamento.  
- Campos principais:
  - Nome da IA  
  - Ano de lançamento  
  - ID do fabricante  
  - ID da categoria/grupo  
  - Upload de logomarca/imagem da IA  
- Ações disponíveis:
  - Salvar IA com validação de integridade (verifica se IDs de fabricante e categoria existem).  
  - Limpar formulário.  
  - Pesquisar IAs já cadastradas.  
  - Excluir IA selecionada do banco de dados. [attached_file:49]

### 2. Cadastro de Categoria
- Permite agrupar IAs por tipo, característica ou funcionalidade.  
- Campos:
  - Nome da categoria (ex.: “Chatbots”, “Assistentes Virtuais”).  
  - Profissão/descrição.  
- Ações:
  - Salvar nova categoria com validação dos dados.  
  - Limpar campos para novo cadastro. [attached_file:49]

### 3. Cadastro de Fabricante
- Tela para registrar as empresas ou responsáveis por cada IA.  
- Campos típicos:
  - Nome do fabricante.  
  - Nome do proprietário ou responsável.  
- Ações:
  - Salvar fabricante garantindo que não haja duplicidade e que campos obrigatórios estejam preenchidos.  
  - Limpar formulário para reiniciar o preenchimento. [attached_file:49]

## 🗃️ Banco de Dados e Regras

- Banco de dados relacional, com tabelas para:
  - IAs  
  - Categorias  
  - Fabricantes  
- O sistema realiza:
  - Verificação da existência dos IDs de fabricante e categoria antes de salvar uma IA.  
  - Bloqueio de gravação quando algum ID é inválido, exibindo mensagem de erro ao usuário.  
- Funções SQL adicionais são usadas para cálculos e geração de relatórios internos. [attached_file:49]

## 🖼️ Recursos Visuais

- Interface com:
  - Tela de carregamento (splash) ao iniciar o sistema.  
  - Tela principal de cadastro de IA com exibição da logomarca selecionada.  
- Suporte a upload de imagens (logomarca da IA), com recomendação de formatos como JPEG ou PNG. [attached_file:49]

## ▶️ Fluxo básico de uso

1. Abrir o sistema: é exibida a tela de carregamento e depois a tela de **Cadastro de IA**.  
2. Caso seja o primeiro uso:
   - Acessar a tela de **Fabricante** para cadastrar produtores.  
   - Acessar a tela de **Categoria** para cadastrar categorias.  
3. Voltar à tela de **Cadastro de IA**:
   - Preencher os campos de Nome, Ano, IDs de Fabricante e Categoria, e opcionalmente a logomarca.  
   - Salvar o registro.  
4. Utilizar os botões de **Pesquisar**, **Limpar** e **Excluir** conforme a necessidade para manter os dados atualizados. [attached_file:49]

## 🧪 Validações

- Verificação automática dos IDs de fabricante e categoria ao salvar uma IA.  
- Mensagens de erro quando algum dado obrigatório está incorreto ou ausente.  
- Confirmação antes da exclusão definitiva de registros. [attached_file:49]

## 👥 Autoria

Projeto desenvolvido por:  
- Eduardo Pedro Nogueira  
- Raquel Vitória Rodrigues Viana  

Curso Técnico em Desenvolvimento de Sistemas – Etec de Peruíbe – 2024. [attached_file:49]

## 📩 Contato

Em caso de dúvidas ou problemas com o sistema, os usuários podem entrar em contato com os desenvolvedores citados na documentação do projeto. [attached_file:49]
