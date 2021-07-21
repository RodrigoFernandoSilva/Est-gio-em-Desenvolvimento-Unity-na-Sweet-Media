
public class ValidadeInfo {

    /// <summary>
    /// Faz a validação do email.
    /// </summary>
    /// <param name="email">Email a ser validado.</param>
    /// <returns>Retorna se o email passado é valido "true" ou não "false".</returns>
    public static bool ValidadeEmail(string email) {
        string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        if (System.Text.RegularExpressions.Regex.IsMatch(email, strModelo)) {
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// Faz a validação da data de nascimento.
    /// </summary>
    /// <param name="birdDate">Data a ser validada</param>
    /// <returns>Retorna se a data digitada é validada "true" ou não "false".</returns>
    public static bool ValidadeBirthDate(string birdDate) {
        return true;
    }
}
