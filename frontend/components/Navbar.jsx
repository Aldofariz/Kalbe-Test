import { LogOut, Moon, Settings, User } from 'lucide-react'
import Link from 'next/link'
import React from 'react'
import { Avatar, AvatarFallback, AvatarImage } from './ui/avatar'
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { SidebarTrigger } from './ui/sidebar'

const Navbar = () => {
  return (
    <nav className='p-4 flex items-center justify-between shadow-md'>
      {/* Left */}

      <SidebarTrigger className="bg-green-600 text-white rounded-full"/>
      
      {/* Right */}
        <div className='flex items-center gap-4'>
            <Moon/>
            {/* <Link href="/">Panggalih Sako Denta</Link> */}
            <DropdownMenu>
              <DropdownMenuTrigger>
                <div className='flex items-center gap-3 font-sans px-4 border-s-4 border-green-400'>
                <Link href="/">Budi Aditya</Link>
                <Avatar>
                  <AvatarImage src="https://github.com/shadcn.png" />
                  <AvatarFallback>BA</AvatarFallback>
                </Avatar>
                </div>
              </DropdownMenuTrigger>
              <DropdownMenuContent sideOffset={10}>
                <DropdownMenuLabel>My Account</DropdownMenuLabel>
                <DropdownMenuSeparator />
                <DropdownMenuItem>
                  <User className='h-[1.2rem] w-[1.2rem] mr-2'/>
                  Profile
                  </DropdownMenuItem>
                <DropdownMenuItem>
                  <Settings className='h-[1.2rem] w-[1.2rem] mr-2'/>
                  Settings
                  </DropdownMenuItem>
                <DropdownMenuItem variant='destructive'>
                  <LogOut className='h-[1.2rem] w-[1.2rem] mr-2'/>
                  Logout
                  </DropdownMenuItem>
              </DropdownMenuContent>
            </DropdownMenu>
        </div>
    </nav>
  )
}

export default Navbar