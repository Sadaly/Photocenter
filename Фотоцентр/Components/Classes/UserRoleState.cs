namespace Фотоцентр.Components.Classes
{
    public class UserRoleState
    {
        public Role CurrentRole { get; private set; } = Role.none;

        public void SetRole(Role role)
        {
            CurrentRole = role;
        }

        public bool IsAdmin()
        {
            return CurrentRole == Role.admin;
        }
    }

    public enum Role
    {
        none,
        admin,
        client,
        manager,
        photographer,
    }
}