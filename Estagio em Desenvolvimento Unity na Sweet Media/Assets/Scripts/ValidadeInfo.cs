using System.Text.RegularExpressions;

public class ValidadeInfo {

    /// <summary>
    /// Faz a validação do email.
    /// </summary>
    /// <param name="email">Email a ser validado.</param>
    /// <returns>Retorna se o email passado é valido "true" ou não "false".</returns>
    public static bool ValidadeEmail(string email) {
        //^([0-9A-Za-z]([-.\w]*[0-9A-z])*@([0-9A-z][-\w]*[0-9A-z]\.)+[a-zA-Z]{2,9})$
        string strPattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
        if (Regex.IsMatch(email, strPattern)) {
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
        string strPattern = @"^(\d{2})\/(\d{2})\/(\d+)";
        if (Regex.IsMatch(birdDate, strPattern)) {
            return true;
        } else {
            return false;
        }
    }
}
