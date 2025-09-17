import React from 'react'
import {Home} from 'lucide-react'
import { Sidebar, SidebarContent, SidebarFooter, SidebarGroup, SidebarGroupContent, SidebarGroupLabel, SidebarHeader, SidebarMenu, SidebarMenuButton, SidebarMenuItem } from './ui/sidebar'
import Link from 'next/link'

const items_menu = [
{
  title: "Dashboard",
  url: "/",
},
{
  title: "Request",
  url: "#",
},
{
  title: "Tracking Progress",
  url: "#",
  
},
{
  title: "Data History",
  url: "#",
},
{
  title: "Document",
  url: "#",
}
]

const items_user = [
{
  title: "Profile",
  url: "/",
},
{
  title: "Change Password",
  url: "#",
},

]
const items_master = [
{
  title: "Parameter",
  url: "/master_param",
},
{
  title: "Sample Type",
  url: "/master_sample",
},
{
  title: "Method",
  url: "/master_method",
},
{
  title: "Analysis",
  url: "/master_analysis",
}
]

const AppSideBar = () => {
  return (
    <Sidebar>
      <SidebarHeader></SidebarHeader>
      <SidebarContent>
        <SidebarGroup>
          <SidebarGroupLabel className="text-md text-green-600 font-semibold font-sans">MAIN MENU</SidebarGroupLabel>
          <SidebarGroupContent>
            <SidebarMenu>
              {items_menu.map(item=>(
                <SidebarMenuItem key={item.title} className="font-semibold font-sans">
                  <SidebarMenuButton asChild>
                    <Link href={item.url}>
                      <span>{item.title}</span>
                    </Link>
                  </SidebarMenuButton>
                </SidebarMenuItem>
              ))}
            </SidebarMenu>
          </SidebarGroupContent>
        </SidebarGroup>

        <SidebarGroup>
          <SidebarGroupLabel className="text-md text-green-600 font-semibold font-sans">USER</SidebarGroupLabel>
          <SidebarGroupContent>
            <SidebarMenu>
              {items_user.map(item=>(
                <SidebarMenuItem key={item.title} className="font-semibold font-sans">
                  <SidebarMenuButton asChild>
                    <Link href={item.url}>
                      <span>{item.title}</span>
                    </Link>
                  </SidebarMenuButton>
                </SidebarMenuItem>
              ))}
            </SidebarMenu>
          </SidebarGroupContent>
        </SidebarGroup>

        <SidebarGroup>
          <SidebarGroupLabel className="text-md text-green-600 font-semibold font-sans">MASTER</SidebarGroupLabel>
          <SidebarGroupContent>
            <SidebarMenu>
              {items_master.map(item=>(
                <SidebarMenuItem key={item.title} className="font-semibold font-sans">
                  <SidebarMenuButton asChild>
                    <Link href={item.url}>
                      <span>{item.title}</span>
                    </Link>
                  </SidebarMenuButton>
                </SidebarMenuItem>
              ))}
            </SidebarMenu>
          </SidebarGroupContent>
        </SidebarGroup>
      </SidebarContent>
      <SidebarFooter></SidebarFooter>
    </Sidebar>
  )
}

export default AppSideBar