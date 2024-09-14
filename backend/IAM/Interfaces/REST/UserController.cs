﻿using System.Net.Mime;
using backend.IAM.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend.IAM.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController(IUserQueryServices userQueryServices) : ControllerBase
{
 [HttpGet]
 public async Task<IActionResult> GetAllUsers()
 {
  var getAllUsersQuery = new GetAllUsersQuery();
  var users = await userQueryServices.Handle(getAllUsersQuery);
  var userResources = users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
  return Ok(userResources);
 }

 [HttpGet("{id}")]
 public async Task<IActionResult> GetUserById(int id)
 {
  var getUserByIdQuery = new GetUserByIdQuery(id);
  var user = await userQueryServices.Handle(getUserByIdQuery);
  var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
  return Ok(userResource);
 }
 
}